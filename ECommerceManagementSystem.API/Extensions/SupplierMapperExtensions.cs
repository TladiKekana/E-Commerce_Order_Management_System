using ECommerceManagementSystem.Application.DTOs;
using ECommerceManagementSystem.Domain.Entities;

namespace ECommerceManagementSystem.API.Extensions
{
    public static class SupplierMapperExtensions
    {
        // Entity to Dto
        public static SupplierResponseDto ToResponseDto(this Supplier supplier)
        {
            return new SupplierResponseDto
                (
                    supplier.Supplier_Id,
                    supplier.Name,
                    supplier.Contact_Person,
                    supplier.Email,
                    supplier.Phone,
                    supplier.Address,
                    supplier.Status
                );
        }

        public static List<SupplierResponseDto> ToResponseDto(this List<Supplier> suppliers)
        {
            List<SupplierResponseDto> response = new List<SupplierResponseDto>();

            foreach ( var supplier in suppliers )
            {
                response.Add(new SupplierResponseDto(
                        supplier.Supplier_Id,
                        supplier.Name,
                        supplier.Contact_Person,
                        supplier.Email,
                        supplier.Phone,
                        supplier.Address,
                        supplier.Status
                    ));
            }

            return response;
        }

        // Dto to Entity
        public static Supplier ToEntity(this AddSupplierRequestDto request)
        {
            return new Supplier 
            {
                Name = request.SupplierName,
                Contact_Person = request.ContactPerson,
                Email = request.Email,
                Phone = request.Phone,
                Address = request.Address,
                Status = request.Status
            };
        }

        public static Supplier ToEntity(this UpdateSupplierRequestDto request)
        {
            return new Supplier 
            {
                Supplier_Id = request.SupplierId,
                Name = request.SupplierName,
                Contact_Person = request.ContactPerson,
                Email = request.Email,
                Phone = request.Phone,
                Address = request.Address,
                Status = request.Status
            };
        }
    }
}
