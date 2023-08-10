using Domain.Entities.Fiancial;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace Database.Seeds
{
    public static class FinancialFinancialReleaseTypeSeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            SeedDefaultTypes(modelBuilder);
        }

        
        private static void SeedDefaultTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FinancialReleaseType>().HasData(
                new FinancialReleaseType { Id = 1, Uuid = Guid.Parse("9E015083-37B2-4FA3-A017-993AD5069CA8"), Name = "Salário", Description = "Recebimento de salário", Operation = EFinancialOperation.INFLOW, Status = Util.Enumerartor.EGenericStatus.Ativo },
                new FinancialReleaseType { Id = 2, Uuid = Guid.Parse("80A4DB26-8161-4080-B987-6591CF4C0320"), Name = "Aluguel", Description = "Pagamento de Aluguel", Operation = EFinancialOperation.OUTFLOW, Status = Util.Enumerartor.EGenericStatus.Ativo },
                new FinancialReleaseType { Id = 3, Uuid = Guid.Parse("7F420E97-B563-4378-8088-EDB359789BA1"), Name = "Outras Receitas", Description = "Outras Receitas", Operation = EFinancialOperation.INFLOW, Status = Util.Enumerartor.EGenericStatus.Ativo },
                new FinancialReleaseType { Id = 4, Uuid = Guid.Parse("AC72349E-3292-4468-84E3-63157CEF3C63"), Name = "Outras Despesas", Description = "Outras Despesas", Operation = EFinancialOperation.OUTFLOW, Status = Util.Enumerartor.EGenericStatus.Ativo }
            );
        }
    }

}
