using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BlogSpa.Contracts;
using BlogSpa.Model;

namespace BlogSpa.Web.Controllers
{
    public class PostsController : ApiController
    {
        private IBlogSpaUnitOfWork _uow;

        public PostsController(IBlogSpaUnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<Post> Get()
        {
            return _uow.Posts.GetAll();
        }
    }
}
