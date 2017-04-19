﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bdWorker
{
    public class Component
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ShellTypeId { get; set; }
        public Guid ProducerId { get; set; }
        public string Image { get; set; }
        public Guid ComponentClassId { get; set; }
        public List<Characteristic> Characteristics { get; set; }
        public List<Consignment> Consignments { get; set; }
        public List<ParsingPage> ParsingPages { get; set; }
        public List<TechnicalDocumentation> TechnicalDocumentations { get; set; }
        public List<Device> Devices { get; set; }
        public ShellType ShellType { get; set; }
        public Producer Producer { get; set; }
        public ComponentClass ComponentClass { get; set; }
    }
}
