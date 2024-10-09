CREATE TABLE STUDENT (
    StudentId BIGINT PRIMARY KEY IDENTITY,
    StudentName VARCHAR(50) NOT NULL,
    Email VARCHAR(20) 
);

CREATE TABLE SUBJECT (
    SubjectId BIGINT PRIMARY KEY IDENTITY,
    SubjectName VARCHAR(50) NOT NULL,
    SubjectCode VARCHAR(10) NOT NULL
);

CREATE TABLE EXAM (
    ExamId BIGINT PRIMARY KEY IDENTITY,
    ExamName VARCHAR(20) NOT NULL,
    MinMark INT NOT NULL,
    MaxMark INT NOT NULL
);
INSERT INTO STUDENT (StudentName, Email)
VALUES 
('John Doe', 'john@example.com'),
('Jane Smith', 'jane@example.com'),
('Mike Johnson', 'mike@example.com');

INSERT INTO SUBJECT (SubjectName, SubjectCode)
VALUES 
('Mathematics', 'MATH101'),
('Physics', 'PHY101'),
('Chemistry', 'CHEM101');

INSERT INTO EXAM (ExamName, MinMark, MaxMark)
VALUES 
('Mid Term', 0, 100),
('Final Exam', 0, 100),
('Quiz', 0, 50);


CREATE TABLE MARKS (
    MarkId BIGINT PRIMARY KEY IDENTITY,
    ExamId BIGINT,
    SubjectId BIGINT,
    StudentId BIGINT,
    Mark INT NOT NULL,
    CONSTRAINT FK_ExamId FOREIGN KEY (ExamId) REFERENCES EXAM(ExamId),
    CONSTRAINT FK_SubjectId FOREIGN KEY (SubjectId) REFERENCES SUBJECT(SubjectId),
    CONSTRAINT FK_StudentId FOREIGN KEY (StudentId) REFERENCES STUDENT(StudentId)
);
INSERT INTO MARKS (ExamId, SubjectId, StudentId, Mark)
VALUES 
(1, 1, 1, 85), 
(1, 2, 2, 70),  
(2, 3, 3, 95),  
(3, 1, 1, 45),  
(2, 2, 2, 88);  

SELECT student.StudentId,student.StudentName,student.Email
FROM marks , student
WHERE marks.StudentId=student.StudentId;

SELECT 
    student.StudentId, 
    student.StudentName, 
    subject.SubjectName, 
    marks.Mark
FROM 
    MARKS marks
INNER JOIN 
    STUDENT student ON marks.StudentId = student.StudentId
INNER JOIN 
    SUBJECT subject ON marks.SubjectId = subject.SubjectId
WHERE 
    subject.SubjectName = 'Mathematics';  
