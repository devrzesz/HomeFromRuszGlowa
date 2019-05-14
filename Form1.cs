using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeFromRuszGlowa
{
    public partial class Form1 : Form
    {
        //deklaracja zmiennych referencyjnych
        Room diningRoom;
        RoomWithDoor livingRoom, kitchen;
        Outside garden;
        OutsideWithDoor frontYard, backYard;
        Location currentLocation;

        public Form1()
        {
            InitializeComponent();
            CreateObjects();
        }

        private void Description_TextChanged(object sender, EventArgs e)
        {
            description.Text = currentLocation.Desciption;
        }

        private void CreateObjects()
        {
            livingRoom = new RoomWithDoor("salon", "antyczny dywan", "dębowe drzwi z klamką");
            livingRoom.Exits = new Location[] { frontYard, diningRoom };

            diningRoom = new Room("Jadalnia", "dekoracja jadalni");
            diningRoom.Exits = new Location[] { kitchen, livingRoom };

            kitchen = new RoomWithDoor("Kuchnia", "dekoracje kuchni", "kolejne kuchenne drzwi");
            kitchen.Exits = new Location[] { diningRoom, backYard };

            backYard = new OutsideWithDoor(true, "Podworko z tyłu", "jakas klamka");
            backYard.Exits = new Location[] { kitchen, garden };

            garden = new Outside(true, "Ogród");
            garden.Exits = new Location[] { backYard, frontYard };

            frontYard = new OutsideWithDoor(false, "Podwroko z przodu", "opis drzwi");
            frontYard.Exits = new Location[] { garden, livingRoom };

        }

        private void MoveToANewLocation(Location currentLocation)
        {
            this.currentLocation = currentLocation;
            exits.Items.Clear();
            exits.Items.Add(this.exits);
            exits.SelectedText = 0;
        }
    }
}
