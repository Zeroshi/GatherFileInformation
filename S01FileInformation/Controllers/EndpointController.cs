﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using FileInformationEngine;
using FileInformationEngine.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FileInformationEngine.Controllers
{
    public class EndpointController : Controller
    {
        private string[] testPath = new string[] { @"T:\Documents\TestFolder" };
        private List<FileInformation> _fileInfos = new List<FileInformation>();
        private const string FILE_INFORMATION_TABLE_NAME = "FileInformation";

        private readonly ILogic _logic;

        public EndpointController(ILogic logic)
        {
            _logic = logic;
        }

        //add server name and directories for input

        public void Index()
        {
            _logic.ClearDbTable();

            foreach (var initalDir in testPath)
            {
                _logic.InitialDirFiles(initalDir);
                _logic.DirSearch(initalDir);
            }
        }

        public void Index(string serverName, string[] directories)
        {
            _logic.ClearDbTable();

            foreach (var initalDir in directories)
            {
                _logic.InitialDirFiles(initalDir);
                _logic.DirSearch(initalDir);
            }
        }
    }
}