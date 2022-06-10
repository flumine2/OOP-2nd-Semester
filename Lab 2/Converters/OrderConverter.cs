using Lab_2.DTO;
using LibraryFor2ndLab.DTO;

namespace Lab_2.Converters
{
    class OrderConverter
    {
        public static Order ConvertToModel(OrderDTO orderDTO)
        {
            return new(orderDTO.Id,
                PerformerConverter.ConvertToModel(orderDTO.Performer),
                CustomerConverter.ConvertToModel(orderDTO.Customer),
                orderDTO.OrderCreationTime,
                orderDTO.Price);
        }

        public static OrderDTO ConvertToDTO(Order order)
        {
            return new(order.Id,
                PerformerConverter.ConvertToDTO(order.Performer),
                CustomerConverter.ConvertToDTO(order.Customer),
                order.OrderCreationTime,
                order.Price);
        }
    }
}
