using Dapper;
using DCA.DataAcces.Abstract;
using DCA.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCA.DataAcces
{
    public class ReceiversRepository : IRepository<Receiver>
    {
        private DbConnection _connection;

        public ReceiversRepository()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["appConnection"].ConnectionString;
            _connection = new SqlConnection(connectionString);
        }

        public void Add(Receiver item)
        {
            var sql = "insert into Receivers (Id, CreationDate, DeletedDate, FullName, Address) values (@Id, @CreationDate, @DeletedDate, @FullName, @Address)";
            //var sql = "insert into Receivers values (@Id, @CreationDate, @DeletedDate, @FullName, @Address)";
            var result = _connection.Execute(sql, item);
            if (result < 1) throw new Exception();
        }

        public void Delete(Receiver item)
        {
            //var sql ="delete"
        }

        public void Dispose()
        {
            _connection.Close();
        }

        public ICollection<Receiver> GetAll()
        {
            var sql = "select * from Receivers";
            return _connection.Query<Receiver>(sql).AsList();
        }

        public ICollection<Receiver> GetWith(Func<Receiver, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Receiver item)
        {
            var sql = $"update Receivers set FullName=@FullName, Address=@Address where Id=@Id";
            var result = _connection.Execute(sql, new { item.FullName,item.Address,item.Id});
        }
    }
}
