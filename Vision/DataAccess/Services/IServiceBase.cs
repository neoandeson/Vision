using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Services
{
    public interface IServiceBase<Rq, Rs>
    {
        ServiceResponse<Rs> Create(Rq rqDTO);
        ServiceResponse<Rs> Delete(int id);
        ServiceResponse<Rs> Update(Rq rqDTO);
        ServiceResponse<Rs> Get(int id);
        ServiceResponse<List<Rs>> GetAll();
    }

    public class ServiceResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }

    //Scaffold-DbContext "Server=DESKTOP-UH7HU37\TIENTPSQL;Database=Vision;User ID=sa;Password=1234;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force
}
