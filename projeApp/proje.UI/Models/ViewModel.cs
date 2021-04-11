using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proje.UI.Models
{
    public class ViewModel
    {
        public IEnumerable<Menu> Menus { get; set; }
        public Menu Menu { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }
        public Blog Blog { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public Comment Comment { get; set; }
        public IEnumerable<Constant> Constants { get; set; }
        public Constant Constant { get; set; }
        public IEnumerable<Promotion> Promotions { get; set; }
        public Promotion Promotion { get; set; }
        public IEnumerable<About> Abouts { get; set; }
        public About About { get; set; }
        public IEnumerable<Slider> Sliders { get; set; }
        public Slider Slider { get; set; }
        public IEnumerable<Popup> Popups { get; set; }
        public Popup Popup { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Form> Forms { get; set; }
        public Form Form { get; set; }
        public IEnumerable<FormElement> FormElements { get; set; }
        public FormElement FormElement { get; set; }
        public IEnumerable<FormElementItem> FormElementItems { get; set; }
        public FormElementItem FormElementItem { get; set; }
        public IEnumerable<Personel> Personels { get; set; }
        public Personel Personel { get; set; }
        public IEnumerable<Like> Likes { get; set; }
        public Like Like { get; set; }
        public IEnumerable<CreatePage> CreatePages { get; set; }
        public CreatePage CreatePage { get; set; }
        public IEnumerable<Purpose> Purposes { get; set; }
        public Purpose Purpose { get; set; }
        public IEnumerable<FormArchive> FormArchives { get; set; }
        public FormArchive FormArchive { get; set; }
        public IEnumerable<Mail> Mails { get; set; }
        public Mail Mail { get; set; }
         public IEnumerable<Contact> Contacts { get; set; }
        public Contact Contact { get; set; }

    }
}
