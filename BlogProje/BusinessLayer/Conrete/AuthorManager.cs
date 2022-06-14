using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Conrete
{
    public class AuthorManager:IAuthorService
    {
        IAuthorDal _authordal;
        Repository<Author> repoauthor = new Repository<Author>();

        public AuthorManager(IAuthorDal authordal)
        {
            _authordal = authordal;
        }     

        public List<Author> GetList()
        {
            return _authordal.List();
        }

        public void AuthorAdd(Author author)
        {
            _authordal.Insert(author);
        }

        public Author GetByID(int id)
        {
            return _authordal.GetByID(id);
        }

        public void AuthorDelete(Author author)
        {
            throw new NotImplementedException();
        }

        public void AuthorUpdate(Author author)
        {
            _authordal.Update(author);
        }


        public void AuthorStatusFalseBL(int id)
        {
            Author author = _authordal.Find(a => a.AuthorID == id);

            author.AuthorStatus = false;
            _authordal.Update(author);
        }

        public void AuthorStatusTrueBL(int id)
        {
            Author author = _authordal.Find(a => a.AuthorID == id);

            author.AuthorStatus = true;
            _authordal.Update(author);
        }

        public void TAdd(Author t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Author t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Author t)
        {
            throw new NotImplementedException();
        }
    }
}
