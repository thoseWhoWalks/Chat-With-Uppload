using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Model.Data;

namespace App.Model.Services 
{
    public class UnitOfWork
    {
        private readonly DB_Context db_context = new DB_Context();
        private static UnitOfWork _instance = new UnitOfWork();
        private AccountServices _accountService;
        private MessageService _messageService;
        private ImageService _imageService;
        private FileService _fileService;

        private UnitOfWork()
        {

        }

        public static UnitOfWork Instance => _instance;
        public AccountServices AccountService => _accountService ?? (_accountService = new AccountServices(db_context));
        public MessageService MessageService => _messageService ?? (_messageService = new MessageService(db_context));
        public ImageService ImageService => _imageService ?? (_imageService = new ImageService(db_context));
        public FileService FileService => _fileService ?? (_fileService = new FileService(db_context));

    }
}
