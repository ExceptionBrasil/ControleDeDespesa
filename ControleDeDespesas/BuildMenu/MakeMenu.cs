using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildMenu
{
    public static class MakeMenu
    {
        public static List<Menu> Menus = new List<Menu>();


        /// <summary>
        /// Adiciona um menu a Lista de Menus
        /// </summary>
        /// <param name="Controller">The controller.</param>
        /// <param name="Action">The action.</param>
        /// <param name="Descricao">The descricao.</param>
        public static void Add(string Controller, string Action,string Location,int Position,int Order, string Descricao =null,string Role = null, string Glyphicon=null)
        {
            if (Descricao == null)
            {
                Descricao = Action;
            }

            if(Role == null)
            {
                Role = "All";
            }

            if (Glyphicon == null)
            {
                Glyphicon = "";
            }

            
            if( MakeMenu.Menus.Find(x=> x.Action ==Action && x.Controller == Controller) == null)
            {
                MakeMenu.Menus.Add(new Menu()
                {
                    
                    
                    Controller = Controller,
                    Action = Action,
                    Location = Location,
                    Position = Position,
                    Order = Order,
                    Descricao = Descricao,
                    Glyphicon = Glyphicon,
                    Role = Role
                });
            }
        }

        /// <summary>
        /// Recupera todos os Menus de um controller
        /// </summary>
        /// <param name="Controller">The controller.</param>
        /// <returns></returns>
        public static List<Menu> Recovery(string Controller)
        {
            List<Menu> Menus = MakeMenu.Menus.FindAll(x => x.Controller == Controller);
            return Menus;
        }


        /// <summary>
        /// Retorna todos os Menus com a mesma Action dentro do Controller
        /// </summary>
        /// <param name="Action">The action.</param>
        /// <returns></returns>
        public static List<Menu> Recovery(string Controller ,string Action)
        {
            List<Menu> Menus = MakeMenu.Menus.FindAll(x => x.Controller == Controller && x.Action == Action);
            return Menus;
        }

        /// <summary>
        /// Recupera todos os Menus de um controller
        /// </summary>
        /// <param name="Controller">The controller.</param>
        /// <returns></returns>
        public static List<Menu> RecoveryByLocation(string Location)
        {
            //List<Menu> Menus = MakeMenu.Menus.FindAll(x => x.Location == Location);
            
            var Menus = from m in MakeMenu.Menus
                        where m.Location == Location
                        orderby m.Position
                        orderby m.Order
                        select m;


            return Menus.ToList();
        }

        /// <summary>
        /// Retorna todos os Menus com a mesma Action 
        /// </summary>
        /// <param name="Action">The action.</param>
        /// <returns></returns>
        public static List<Menu> RecoveryByAction( string Action)
        {
            List<Menu> Menus = MakeMenu.Menus.FindAll(x => x.Action == Action);
            return Menus;
        }


    }
}
