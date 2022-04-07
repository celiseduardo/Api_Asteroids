using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using WebAPI.Models.Helpers;
using Xunit;

namespace xUnitTesting
{

    public class AsteroidsServiceShould
    {
        [Fact]
        public void Validate() { 
        
           //Arrange

            //Declaraciones de objetos o variables.

            //Act
           //  bool isValid = Llamado del Metodo
            bool isValid = true;


            //Assert
            Assert.True(isValid, $"Error al ejecutar el test");

        }



        //[Fact]
        //public async Task Test_Get_All()
        //{

        //    Dates dates = _helpers.getDatesFromToday(int.Parse(Days));

        //    List<Parameters> param = new List<Parameters>();
        //    param.Add(new Parameters() { Key = "start_date", Value = dates.StartDate.ToString("yyyy-MM-dd") });
        //    param.Add(new Parameters() { Key = "end_date", Value = dates.EndDate.ToString("yyyy-MM-dd") });

        //    string Url = _apiUrl.GetUrl("APINeoFeed", param);

        //    using (var client = new TestClientProvider().Client)
        //    {
        //        var response = await client.GetAsync("/api/employee");

        //        response.EnsureSuccessStatusCode();

        //        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        //    }

        //}

            //[Theory]
            //[InlineData ("invalid@dasda", false)]
            //[InlineData("valido@dasda", true)]
            //public void Validw2ate2(string dato, string expected)
            //{

            //    //Preparacion

            //    -- Declaraciones de objetos o variables.

            //    //Prueba

            //    //  bool isValid = Llamado del Metodo0
            //     dato = "valido@dasda";


            //    //Verificacion

            //    Assert.Equal(dato, expected);

            //}

        }
}
