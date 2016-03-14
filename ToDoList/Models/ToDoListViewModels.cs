using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    /// <summary>
    /// ToDoList Model
    /// </summary>
    public class ToDoListViewModels
    {
        //編號
        public int ID { get; set; }

        //代辦事項
        [Display(Name = "代辦事項")]
        public string Title { get; set; }

        [Display(Name = "時間")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //時間
        public DateTime Date { get; set; }

        //描述
        [Display(Name = "描述")]
        public string Description { get; set; }
    }

    public class ToDoListDBContext : DbContext
    {
        public DbSet<ToDoListViewModels> toDoList { get; set; }
    }
}
