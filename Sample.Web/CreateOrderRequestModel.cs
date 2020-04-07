using Domain.Commands;

namespace Web
{
    public class CreateOrderRequestModel: 
        ICommand
    {
        public string UserId { get; set; }
        public string CardNumber { get; set; }
    }  
        
}