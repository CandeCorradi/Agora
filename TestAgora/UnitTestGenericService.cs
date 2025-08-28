using Service.Interfaces;
using Service.Models;
using Service.Services;

namespace TestAgora { }
public class UnitTestGenericService
{
    public class UnitTest1GenericServices
    {
        [Fact]
        public async void TestGetAllInscripciones()
        {
            var service = new GenericService<Inscripcion>();
            var result = await service.GetAllAsync(null);
            Assert.NotNull(result);
            Assert.IsType<List<Inscripcion>>(result);
            Assert.True(result.Count > 0);
            foreach (var item in result)
            {
                Console.WriteLine($"Id: {item.Id}, Nombre: {item.Nombre}");
            }

        }
        [Fact]
        public async void TestGetAllCapacitaciones()
        {
            var service = new GenericService<Capacitacion>();
            var result = await service.GetAllAsync(null);
            Assert.NotNull(result);
            Assert.IsType<List<Capacitacion>>(result);
            Assert.True(result.Count > 0);
            foreach (var item in result)
            {
                Console.WriteLine($"Id: {item.Id}, Nombre: {item.Nombre}");
            }

        }
        [Fact]
        public async void TestGetAllUsuarios()
        {
            var service = new GenericService<Usuario>();
            var result = await service.GetAllAsync(null);
            Assert.NotNull(result);
            Assert.IsType<List<Usuario>>(result);
            Assert.True(result.Count > 0);
            foreach (var item in result)
            {
                Console.WriteLine($"Id: {item.Id}, Nombre: {item.Nombre}");
            }

        }
        [Fact]
        public async void TestGetAllTipoInscripciones()
        {
            var service = new GenericService<TipoInscripcion>();
            var result = await service.GetAllAsync(null);
            Assert.NotNull(result);
            Assert.IsType<List<TipoInscripcion>>(result);
            Assert.True(result.Count > 0);
            foreach (var item in result)
            {
                Console.WriteLine($"Id: {item.Id}, Nombre: {item.Nombre}");
            }

        }
        [Fact]
        public async void TestGetAllTiposInscripcionesCapacitaciones()
        {
            var service = new GenericService<TipoInscripcionCapacitacion>();
            var result = await service.GetAllAsync(null);
            Assert.NotNull(result);
            Assert.IsType<List<TipoInscripcionCapacitacion>>(result);
            Assert.True(result.Count > 0);
            foreach (var item in result)
            {
                Console.WriteLine($"Id: {item.Id}, CapacitacionID: {item.CapacitacionId}");
            }

        }
        [Fact]
        public async void TestGetByIdTiposInscripcionesCapacitaciones()
        {
            var service = new GenericService<TipoInscripcion>();
            var idToTest = 1;
            var result = await service.GetByIdAsync(idToTest);
            Assert.NotNull(result);
            Assert.IsType<TipoInscripcion>(result);
            Assert.Equal(idToTest, result.Id);
            Assert.Equal("Público en general", result.Nombre);
            Console.WriteLine($"Id: {result.Id}, CapacitacionID: {result.Nombre}");


        }
        [Fact]
        public async void TestDeleteInscripciones()
        {
            //arrange
            var service = new GenericService<Inscripcion>();
            //act
            var idToDelete = 5;
            var result = await service.DeleteAsync(idToDelete);
            Assert.True(result);
            Console.WriteLine($"Inscripcion con Id: {idToDelete} eliminado correctamente");


        }
        [Fact]
        public async void TestAddTipoInscripcion()
        {
            var service = new GenericService<TipoInscripcion>();
            var newTipoInscripcion = new TipoInscripcion
            {
                Nombre = "Estudiante Instituto"
            };
            var result = await service.AddAsync(newTipoInscripcion);
            Assert.NotNull(result);
            Assert.IsType<TipoInscripcion>(result);
            Assert.Equal(newTipoInscripcion.Nombre, result.Nombre);
            Console.WriteLine($"Id {result.Id}, Nombre {result.Nombre}");


        }
        [Fact]
        public async void TestDeletedsCapacitaciones()
        {
            //arrange: construccion del contecto
            var service = new GenericService<Capacitacion>();
            //act: accion que queremos testear
            var result = await service.GetAllDeletedsAsync(null);
            //Assert: el resultado sea lo esperado.
            Assert.NotNull(result);
            Assert.IsType<List<Capacitacion>>(result);
            Assert.True(result.Count == 1);
            foreach (var item in result)
            {
                Console.WriteLine($"Id: {item.Id}, Nombre: {item.Nombre}");
            }

        }
        [Fact]
        public async void TestUpdateTipoInscripcion()
        {
            //arrange
            var service = new GenericService<TipoInscripcion>();
            var TipoInscripcionAModificar = new TipoInscripcion()
            {
                Id = 2,
                Nombre = "Docente Instituto"
            };
            //action
            var result = await service.UpdateAsync(TipoInscripcionAModificar);
            //
            Assert.NotNull(result);
            Assert.True(result);
        }
        [Fact]
        public async void TestRestoreCapacitacion()
        {
            // Arrange
            var service = new GenericService<Capacitacion>();
            int idToRestore = 3; // Asumiendo que este ID existe en la base de datos
                                 // Act
            var result = await service.RestoreAsync(idToRestore);
            // Assert
            Assert.True(result);
            Console.WriteLine($"Capacitacion con Id {idToRestore} restaurada exitosamente.");
        }
    }
}