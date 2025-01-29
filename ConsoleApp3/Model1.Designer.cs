// Создание кода T4 для модели "C:\Users\anton\source\repos\MMRPGG\ConsoleApp3\Model1.edmx" включено. 
// Чтобы включить формирование кода прежних версий, измените значение свойства "Стратегия создания кода" конструктора
// на "Legacy ObjectContext". Это свойство доступно в окне "Свойства", если модель
// открыта в конструкторе.using System;
using ConsoleApp3;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

public partial class LibraryEntities : DbContext
{
    public LibraryEntities()
        : base("name=LibraryEntities")
    {
    }

    protected override void
OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }

    public virtual DbSet<Players> Players { get; set; }
    public virtual DbSet<SaveData> SaveData { get; set; }
}
// Если не сформированы контекст и классы сущности, возможная причина в том, что вы создали пустую модель, но
// еще не выбрали версию Entity Framework для использования. Чтобы сформировать класс контекста и классы сущностей
// для своей модели, откройте модель в конструкторе, щелкните правой кнопкой область конструктора и
// выберите "Обновить модель из базы данных", "Сформировать базу данных из модели" или "Добавить элемент формирования
// кода...".