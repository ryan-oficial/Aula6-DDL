﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EfCore2.Utils
{
    public static class Upload
    {
        public static string Local(IFormFile file)
        {
            var nomeArquivo = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);

            var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), @"wwwRoot\upload\imagens", nomeArquivo);


            using var streamImagem = new FileStream(caminhoArquivo, FileMode.Create);

            file.CopyTo(streamImagem);
            return "http://localhost:51557/upload/imagens/" + nomeArquivo;
                }
    }
}
