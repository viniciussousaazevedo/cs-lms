using cs_lms.repository;

namespace cs_lms.controller;

public class LibraryController
{
    private LibraryRepository _repository = new();

    public LibraryController()
    {
        _repository.Populate();
    }
}