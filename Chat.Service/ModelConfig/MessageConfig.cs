using SDMS.Service.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.ModelConfig
{
    class MessageConfig : EntityTypeConfiguration<MessageEntity>
    {
        public MessageConfig()
        {
            ToTable("T_Message");
            Property(m => m.Contents).HasMaxLength(200);
            HasRequired(m => m.Holder).WithMany().HasForeignKey(m => m.HolderId).WillCascadeOnDelete(false);
            HasRequired(m => m.News).WithMany().HasForeignKey(m => m.NewsId).WillCascadeOnDelete(false);
        }
    }
}