using LibraryFor2ndLab.DTO;
using LibraryFor2ndLab.Models;

namespace LibraryFor2ndLab.Converters
{
    public class OrderConverter
    {
        public static Order ConvertToModel(OrderDTO orderDTO)
        {
            return new Order(orderDTO.Id,
                PerformerConverter.ConvertToModel(orderDTO.Performer),
                CustomerConverter.ConvertToModel(orderDTO.Customer),
                orderDTO.OrderCreationTime,
                orderDTO.Price);
        }

        public static OrderDTO ConvertToDTO(Order order)
        {
            return new OrderDTO(order.Id,
                PerformerConverter.ConvertToDTO(order.Performer),
                CustomerConverter.ConvertToDTO(order.Customer),
                order.OrderCreationTime,
                order.Price);
        }
    }
}
