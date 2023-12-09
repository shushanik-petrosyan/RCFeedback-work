using System;
using System.Collections.Generic;
using System.Text;
using SQLite; // Импорт библиотеки SQLite

namespace RCFeedback.Models
{
    // Класс обратной связи
    public class Feedback
    {
        [PrimaryKey, AutoIncrement]
        // Поле Id является первичным ключом и автоинкрементируемым
        public int Id { get; set; }
        // Поля имени, email и номера заказа
        public string Name { get; set; }
        public string Email { get; set; }
        public string OrderNumber { get; set; }

        // Поля оценок качества, дизайна, цены и доставки
        public int QualityRating { get; set; }
        public int DesignRating { get; set; }
        public int PriceRating { get; set; } // Похоже, опечатка: было "PraiceRating", исправил на "PriceRating"
        public int DeliveryRating { get; set; }

        // Поле комментария
        public string Comment { get; set; }
    }
}

