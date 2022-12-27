using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Abstract
{
    public interface ICommentService:IGenericService<Comment>
    {
        List<Comment> GetList(int id); 
        List<Comment> GetCommentWithBlog();

    }
}
