using System;
using System.Collections.Generic;

namespace ComputerBuilder
{
   
    public class Computer
    {
        public string CPU { get; set; }
        public string GPU { get; set; }
        public int RAM { get; set; } 
        public string Storage { get; set; }
        public string OS { get; set; }
        public List<string> AdditionalComponents { get; set; } = new List<string>();
        public string CoolingSystem { get; set; } 
        public string PowerSupply { get; set; }

        public void DisplayConfiguration()
        {
            Console.WriteLine("Конфигурация компьютера");
            Console.WriteLine($"Процессор: {CPU}");
            Console.WriteLine($"Видеокарта: {GPU}");
            Console.WriteLine($"Оперативная память: {RAM} ГБ");
            Console.WriteLine($"Хранилище: {Storage}");
            Console.WriteLine($"Операционная система: {OS}");
            Console.WriteLine($"Блок питания: {PowerSupply}");
            Console.WriteLine($"Система охлаждения: {CoolingSystem}");

            if (AdditionalComponents.Count > 0)
            {
                Console.WriteLine("Дополнительные компоненты:");
                foreach (var component in AdditionalComponents)
                {
                    Console.WriteLine($"  - {component}");
                }
            }
            Console.WriteLine();
        }
    }

    
    public interface IComputerBuilder
    {
        void SetCPU();
        void SetGPU();
        void SetRAM();
        void SetStorage();
        void SetOS();
        void SetAdditionalComponents();
        void SetCoolingSystem();
        void SetPowerSupply();
        Computer GetResult();
    }

    
    public class GamingComputerBuilder : IComputerBuilder
    {
        private Computer _computer = new Computer();

        public GamingComputerBuilder()
        {
            this.Reset();
        }

        private void Reset()
        {
            _computer = new Computer();
        }

        public void SetCPU()
        {
            _computer.CPU = "Intel Core i9-14900K";
        }

        public void SetGPU()
        {
            _computer.GPU = "NVIDIA RTX 4090";
        }

        public void SetRAM()
        {
            _computer.RAM = 64; 
        }

        public void SetStorage()
        {
            _computer.Storage = "2TB NVMe SSD + 4TB HDD";
        }

        public void SetOS()
        {
            _computer.OS = "Windows 11 Pro";
        }

        public void SetAdditionalComponents()
        {
            _computer.AdditionalComponents.AddRange(new List<string>
            {
                "Механическая игровая клавиатура",
                "Игровая мышь с RGB",
                "Игровой монитор 240 Гц",
                "Звуковая карта 7.1"
            });
        }

        public void SetCoolingSystem()
        {
            _computer.CoolingSystem = "Жидкостная система охлаждения (AIO 360mm)"; 
        }

        public void SetPowerSupply()
        {
            _computer.PowerSupply = "1000W Gold Certified";
        }

        public Computer GetResult()
        {
            Computer result = _computer;
            this.Reset();
            return result;
        }
    }

    
    public class OfficeComputerBuilder : IComputerBuilder
    {
        private Computer _computer = new Computer();

        public OfficeComputerBuilder()
        {
            this.Reset();
        }

        private void Reset()
        {
            _computer = new Computer();
        }

        public void SetCPU()
        {
            _computer.CPU = "Intel Core i5-13400";
        }

        public void SetGPU()
        {
            _computer.GPU = "Интегрированная графика";
        }

        public void SetRAM()
        {
            _computer.RAM = 16; 
        }

        public void SetStorage()
        {
            _computer.Storage = "512GB SSD";
        }

        public void SetOS()
        {
            _computer.OS = "Windows 11 Pro";
        }

        public void SetAdditionalComponents()
        {
            _computer.AdditionalComponents.AddRange(new List<string>
            {
                "Офисная клавиатура и мышь",
                "Веб-камера",
                "Колонки"
            });
        }

        public void SetCoolingSystem()
        {
            _computer.CoolingSystem = "Стандартный кулер процессора"; 
        }

        public void SetPowerSupply()
        {
            _computer.PowerSupply = "500W 80+ Bronze";
        }

        public Computer GetResult()
        {
            Computer result = _computer;
            this.Reset();
            return result;
        }
    }

   
    public class BudgetGamingComputerBuilder : IComputerBuilder
    {
        private Computer _computer = new Computer();

        public BudgetGamingComputerBuilder()
        {
            this.Reset();
        }

        private void Reset()
        {
            _computer = new Computer();
        }

        public void SetCPU()
        {
            _computer.CPU = "AMD Ryzen 5 7600";
        }

        public void SetGPU()
        {
            _computer.GPU = "NVIDIA RTX 4060";
        }

        public void SetRAM()
        {
            _computer.RAM = 32;
        }

        public void SetStorage()
        {
            _computer.Storage = "1TB NVMe SSD";
        }

        public void SetOS()
        {
            _computer.OS = "Windows 11 Home";
        }

        public void SetAdditionalComponents()
        {
            _computer.AdditionalComponents.AddRange(new List<string>
            {
                "Игровая мышь",
                "Игровая клавиатура"
            });
        }

        public void SetCoolingSystem()
        {
            _computer.CoolingSystem = "Башенный кулер с 2 вентиляторами";
        }

        public void SetPowerSupply()
        {
            _computer.PowerSupply = "650W 80+ Bronze";
        }

        public Computer GetResult()
        {
            Computer result = _computer;
            this.Reset();
            return result;
        }
    }

    
    public class ComputerDirector
    {
        private IComputerBuilder _builder;

        public ComputerDirector(IComputerBuilder builder)
        {
            _builder = builder;
        }

        public void SetBuilder(IComputerBuilder builder)
        {
            _builder = builder;
        }

        
        public void BuildBasicComputer()
        {
            _builder.SetCPU();
            _builder.SetGPU();
            _builder.SetRAM();
            _builder.SetStorage();
            _builder.SetPowerSupply();
            _builder.SetCoolingSystem(); 
        }

        
        public void BuildFullComputer()
        {
            BuildBasicComputer();
            _builder.SetOS();
            _builder.SetAdditionalComponents();
        }

        
        public void BuildMinimalComputer()
        {
            _builder.SetCPU();
            _builder.SetGPU();
            _builder.SetRAM();
            _builder.SetStorage();
            _builder.SetPowerSupply();
            _builder.SetCoolingSystem();
            _builder.SetOS();
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {                       
            var gamingBuilder = new GamingComputerBuilder();
            var officeBuilder = new OfficeComputerBuilder();
            var budgetGamingBuilder = new BudgetGamingComputerBuilder();

           
            var director = new ComputerDirector(gamingBuilder);

            Console.WriteLine("1. Сборка ИГРОВОГО компьютера (полная версия):");
            Console.WriteLine("Логика сборки: Мощный процессор, топовая видеокарта, много RAM, жидкостное охлаждение");
            director.SetBuilder(gamingBuilder);
            director.BuildFullComputer();
            var gamingComputer = gamingBuilder.GetResult();
            gamingComputer.DisplayConfiguration();

            Console.WriteLine("2. Сборка ОФИСНОГО компьютера (полная версия):");
            Console.WriteLine("Логика сборки: Экономный процессор, интегрированная графика, стандартный кулер");
            director.SetBuilder(officeBuilder);
            director.BuildFullComputer();
            var officeComputer = officeBuilder.GetResult();
            officeComputer.DisplayConfiguration();

            Console.WriteLine("3. Сборка БЮДЖЕТНОГО игрового компьютера:");
            Console.WriteLine("Логика сборки: Оптимальная цена/качество, башенный кулер");
            director.SetBuilder(budgetGamingBuilder);
            director.BuildFullComputer();
            var budgetGamingComputer = budgetGamingBuilder.GetResult();
            budgetGamingComputer.DisplayConfiguration();

            Console.WriteLine("4. Сборка без директора (ручная настройка):");
            Console.WriteLine("Демонстрация гибкости паттерна - можно собирать объекты пошагово");

            var customBuilder = new GamingComputerBuilder();

            
            customBuilder.SetCPU();
            customBuilder.SetGPU();
            customBuilder.SetRAM();
            
            customBuilder.SetStorage();
            customBuilder.SetOS();
            customBuilder.SetCoolingSystem(); 

            var customComputer = customBuilder.GetResult();
            customComputer.DisplayConfiguration();

            Console.WriteLine("Сравнение систем охлаждения");
            Console.WriteLine("1. Игровой компьютер: Жидкостное охлаждение - эффективно, тихо, для высоких нагрузок");
            Console.WriteLine("2. Офисный компьютер: Стандартный кулер - достаточно для базовых задач");
            Console.WriteLine("3. Бюджетный игровой: Башенный кулер - хороший баланс цены и эффективности");

            Console.WriteLine("Преимущества использованного подхода");
            Console.WriteLine("1. Разделение сложной сборки на простые шаги");
            Console.WriteLine("2. Возможность создания разных представлений одного объекта");
            Console.WriteLine("3. Контроль над процессом конструирования");
            Console.WriteLine("4. Изоляция кода сборки от бизнес-логики");
            Console.WriteLine("5. Легко добавлять новые типы компьютеров (например, серверный, мультимедийный)");

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}