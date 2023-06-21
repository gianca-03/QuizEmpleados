using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class EmpleadoHelper
    {
        ServiceRepository repository;

        public EmpleadoHelper()
        {
            repository = new ServiceRepository();
        }

        public List<EmpleadoViewModel> GetAll()
        {

            List<EmpleadoViewModel> lista = new List<EmpleadoViewModel>();
            HttpResponseMessage responseMessage = repository.GetResponse("api/empleado/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<EmpleadoViewModel>>(content);
            }

            return lista;
        }

        public EmpleadoViewModel GetById(int id)
        {
            EmpleadoViewModel empleado = new EmpleadoViewModel();

            HttpResponseMessage responseMessage = repository.GetResponse("api/empleado/" + id);
            var content = responseMessage.Content.ReadAsStringAsync().Result;

            empleado = JsonConvert.DeserializeObject<EmpleadoViewModel>(content);

            return empleado;
        }

        public EmpleadoViewModel Edit(EmpleadoViewModel empleado)
        {

            HttpResponseMessage responseMessage = repository.PutResponse("api/empleado/", empleado);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            EmpleadoViewModel empleadoAPI = JsonConvert.DeserializeObject<EmpleadoViewModel>(content);
            return empleadoAPI;
        }

        public EmpleadoViewModel Add(EmpleadoViewModel empleado)
        {

            HttpResponseMessage responseMessage = repository.PostResponse("api/empleado/", empleado);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            EmpleadoViewModel empleadoAPI = JsonConvert.DeserializeObject<EmpleadoViewModel>(content);
            return empleadoAPI;
        }

        public EmpleadoViewModel Delete(int id)
        {
            EmpleadoViewModel empleado = new EmpleadoViewModel();

            HttpResponseMessage responseMessage = repository.DeleteResponse("api/empleado/" + id);
            // string content = responseMessage.Content.ReadAsStringAsync().Result;
            // category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

            return empleado;
        }

    } 
}
