namespace PetClinics
{
    using System;
    using System.Linq;

    public class Clinic
    {
        private Pet[] byRoom;
        private int roomIndex;

        public Clinic(int roomCount)
        {
            if (roomCount % 2 == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            byRoom = new Pet[roomCount];
            roomIndex = roomCount / 2;
        }

        public bool HasEmptyRooms => byRoom.Any(pet => pet == null);

        public bool ReleasePet()
        {
            for (int i = 0; i < byRoom.Length; i++)
            {
                int currIndex = (byRoom.Length / 2 + i) % byRoom.Length;

                if (byRoom[currIndex] != null)
                {
                    byRoom[currIndex] = null;
                    return true;
                }
            }

            return false;
        }

        public bool AddPet(Pet pet)
        {
            for (int i = 0; i < byRoom.Length; i++)
            {
                int currIndex = roomIndex;
                IncreaseRoomIndex();

                if (byRoom[currIndex] == null)
                {
                    byRoom[currIndex] = pet;
                    return true;
                }
            }
            return false;
        }

        public void Print()
        {
            for (int i = 0; i < byRoom.Length; i++)
            {
                Print(i);
            }
        }

        public void Print(int room)
        {
            if (byRoom[room] != null)
            {
                Console.WriteLine(byRoom[room]);
            }
            else
            {
                Console.WriteLine("Room empty");
            }
        }

        private void IncreaseRoomIndex()
        {
            int roomCount = byRoom.Length;

            if (roomIndex == roomCount - 1)
            {
                roomIndex = roomCount / 2;
            }
            else
            {
                if (roomIndex >= roomCount / 2)
                {
                    roomIndex = roomCount / 2 - roomIndex + roomCount / 2 - 1;
                }
                else
                {
                    roomIndex = roomCount / 2 + roomCount / 2 - roomIndex;
                }
            }
        }
    }
}
