using BizFlow.API.Common;
using BizFlow.API.Domain.Entities;
using BizFlow.API.Domain.Enums;
using BizFlow.API.Infrastructure.Persistence;
using BizFlow.API.Infrastructure.Repository.Customer;
using BizFlow.API.Infrastructure.Repository.Order;
using BizFlow.API.Infrastructure.Repository.Wallet;
using Microsoft.EntityFrameworkCore;

namespace BizFlow.API.Infrastructure.Repository.Invoice;
public class InvoiceRepository(Context context, ICustomerRepository customerRepository, IOrderRepository orderRepository, IWalletRepository walletRepository) : IInvoiceRepository
{
    public readonly Context context = context;
    public readonly ICustomerRepository customerRepository = customerRepository;
    public readonly IOrderRepository orderRepository = orderRepository;
    public readonly IWalletRepository walletRepository = walletRepository;

    public async Task AddInvoiceAsync(Domain.Entities.Invoice invoice, CancellationToken cancellationToken)
    {
        await context.Invoices.AddAsync(invoice);
        context.SaveChanges();
    }

    public async Task<List<Domain.Entities.Invoice>> GetInvoicesAsync(CancellationToken cancellationToken)
    {
        return await context.Invoices.Include(i => i.OrderId).ToListAsync(cancellationToken);
    }

    public async Task<Domain.Entities.Invoice> GetInvoice(int id,CancellationToken cancellationToken)
    {
        return await context.Invoices.FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
    }

    public async Task<Result> PayInvoice(int invoiceId, int customerId, CancellationToken cancellationToken)
    {
        var invoice = await GetInvoice(invoiceId, cancellationToken);
        if (invoice == null)
            return Result.Fail("فاکتور یافت نشد.");


        var order = await orderRepository.GetAsync(invoice.OrderId, cancellationToken);
        if (!IsOrderOwnedByCustomer(order, customerId))
            return Result.Fail("شما مجاز به پرداخت این فاکتور نیستید.");


        var customer = await customerRepository.GetAsync(customerId,cancellationToken);
        if (customer == null)
            return Result.Fail("مشتری یافت نشد.");



        if (invoice.Status == InvoiceStatus.Paid)
            return Result.Fail("این فاکتور قبلاً پرداخت شده است.");



        if (CanPay(customer , invoice))
            return Result.Fail("موجودی کیف پول کافی نیست.");


        ApplyPayment(customer, invoice);

        await AddWalletTransaction(invoice, customerId, cancellationToken);

        await context.SaveChangesAsync(cancellationToken);

        return Result.Ok("پرداخت با موفقیت انجام شد.");
    }

    private static bool IsOrderOwnedByCustomer(Domain.Entities.Order order, int customerId) =>
    order.CustomerId == customerId;

    private static bool CanPay(Domain.Entities.Customer customer, Domain.Entities.Invoice invoice) =>
        customer.WalletBalance >= invoice.Amount;

    private static void ApplyPayment(Domain.Entities.Customer customer, Domain.Entities.Invoice invoice)
    {
        customer.WalletBalance -= invoice.Amount;
        invoice.Status = InvoiceStatus.Paid;
    }

    private async Task AddWalletTransaction(Domain.Entities.Invoice invoice, int customerId, CancellationToken cancellationToken)
    {
      await  context.WalletTransactions.AddAsync(new WalletTransaction
        {
            CustomerId = customerId,
            Amount = -invoice.Amount,
            Date = DateTime.UtcNow,
            Description = $"پرداخت فاکتور {invoice.Id}"
        },cancellationToken);
    }

}
