using Lab_2.dto;
using LibraryFor2ndLab;
using LibraryFor2ndLab.DTO;

namespace Lab_2.Converters
{
    class OrderConverter
    {
        public static Order ConvertToModel(OrderDTO orderDTO)
        {
            return new(PerformerConverter.ConvertToModel(orderDTO.Performer),
                CustomerConverter.ConvertToModel(orderDTO.Customer),
                orderDTO.OrderCreationTime,
                orderDTO.Price);
        }

        public static OrderDTO ConvertToDTO(Order order)
        {
            return new(PerformerConverter.ConvertToDTO(order.Performer),
                CustomerConverter.ConvertToDTO(order.Customer),
                order.OrderCreationTime,
                order.Price);
        }
    }
}
