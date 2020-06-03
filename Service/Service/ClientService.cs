using EnityModel;
using Repositorie.Repositories;
using Service.Interface;

namespace Service.Service
{
    public class ClientService : IClientService
    {

        private readonly ClientRepository _clientRepository;
       
        public ClientService()
        {
            _clientRepository = new ClientRepository();
        }

        public  ApiResponse<Client> FindClient(string clientId,string clientSecret)
        {
            ApiResponse<Client> response = new ApiResponse<Client>();
            Client client =  _clientRepository.Find(i => i.client_id == clientId&&i.client_secret== clientSecret);
            if (client == null)
            {
                response.Success = false;
            }
            response.Data = client;
            return response;
        }
    }
}
