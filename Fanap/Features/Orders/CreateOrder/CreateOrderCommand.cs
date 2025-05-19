using BizFlow.API.Common;
using BizFlow.API.Domain.Entities;
using MediatR;

namespace BizFlow.API.Features.Orders.CreateOrder;

public record CreateOrderCommand(int CustomerId,int InvoiceId, string? Product, int Quantity, decimal TotalAmount, DateTime OrderDate) : IRequest<Result>;
