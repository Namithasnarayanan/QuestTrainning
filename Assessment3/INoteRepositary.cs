 public interface INoteRepository
 {
     void Create(Note note);
     List<Note> GetAll();
     Note GetById(int id);
     void Update(Note note);
     void Delete(int id);
 }