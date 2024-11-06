 public class NoteService
 {
     private readonly INoteRepository _noteRepository;

     public NoteService(INoteRepository noteRepository)
     {
         _noteRepository = noteRepository;
     }

     public void CreateNote()
     {
         try
         {
             Console.WriteLine("Enter the title of the note:");
             string title = Console.ReadLine();
             Console.WriteLine("Enter the content of the note:");
             string content = Console.ReadLine();

             if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content))
             {
                 Console.WriteLine("Title and Content cannot be empty.");
                 return;
             }

             var note = new Note
             {
                 Title = title,
                 Content = content,
                 CreatedAt = DateTime.Now,
                 UpdatedAt = DateTime.Now
             };

             _noteRepository.Create(note);
             Console.WriteLine("Note created successfully.");
         }
         catch (Exception ex)
         {
             Console.WriteLine($"Error: {ex.Message}");
         }
     }

     public void ViewAllNotes()
     {
         try
         {
             var notes = _noteRepository.GetAll();
             if (notes.Count == 0)
             {
                 Console.WriteLine("No notes available.");
             }
             else
             {
                 foreach (var note in notes)
                 {
                     Console.WriteLine($"ID: {note.Id}, Title: {note.Title}, Created At: {note.CreatedAt}, Content: {note.Content.Substring(0, 20)}...");
                 }
             }
         }
         catch (Exception ex)
         {
             Console.WriteLine($"Error: {ex.Message}");
         }
     }

     public void UpdateNote()
     {
         try
         {
             Console.WriteLine("Enter the ID of the note to update:");
             int id = int.Parse(Console.ReadLine());

             var note = _noteRepository.GetById(id);
             if (note == null)
             {
                 Console.WriteLine("Note not found.");
                 return;
             }

             Console.WriteLine($"Current Title: {note.Title}, Current Content: {note.Content}");
             Console.WriteLine("Enter new title (leave empty to keep the same):");
             string newTitle = Console.ReadLine();
             Console.WriteLine("Enter new content (leave empty to keep the same):");
             string newContent = Console.ReadLine();

             if (!string.IsNullOrEmpty(newTitle)) note.Title = newTitle;
             if (!string.IsNullOrEmpty(newContent)) note.Content = newContent;

             note.UpdatedAt = DateTime.Now;
             _noteRepository.Update(note);
             Console.WriteLine("Note updated successfully.");
         }
         catch (Exception ex)
         {
             Console.WriteLine($"Error: {ex.Message}");
         }
     }

     public void DeleteNote()
     {
         try
         {
             Console.WriteLine("Enter the ID of the note to delete:");
             int id = int.Parse(Console.ReadLine());

             var note = _noteRepository.GetById(id);
             if (note == null)
             {
                 Console.WriteLine("Note not found.");
                 return;
             }

             Console.WriteLine("Are you sure you want to delete this note? (y/n)");
             string confirmation = Console.ReadLine();
             if (confirmation.ToLower() == "y")
             {
                 _noteRepository.Delete(id);
                 Console.WriteLine("Note deleted successfully.");
             }
             else
             {
                 Console.WriteLine("Deletion cancelled.");
             }
         }
         catch (Exception ex)
         {
             Console.WriteLine($"Error: {ex.Message}");
         }
     }

 }