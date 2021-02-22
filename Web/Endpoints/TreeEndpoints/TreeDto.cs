using System;

namespace FamTrees.Web.Endpoints.TreeEndpoints
{
    public class TreeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}