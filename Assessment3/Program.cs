    static void Main(string[] args)
    {

        INoteRepository noteRepository = new NoteRepository();
        NoteService noteService = new NoteService(noteRepository);

        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Create a new note");
            Console.WriteLine("2. View all notes");
            Console.WriteLine("3. Update an existing note");
            Console.WriteLine("4. Delete a note");
            Console.WriteLine("5. Exit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    noteService.CreateNote();
                    break;
                case 2:
                    noteService.ViewAllNotes();
                    break;
                case 3:
                    noteService.UpdateNote();
                    break;
                case 4:
                    noteService.DeleteNote();
                    break;
                case 5:
                    Console.WriteLine("Exiting application...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
