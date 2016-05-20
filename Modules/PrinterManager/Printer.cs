﻿/*
 * FOG Service : A computer management client for the FOG Project
 * Copyright (C) 2014-2016 FOG Project
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 3
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Zazzles;

namespace FOG.Modules.PrinterManager
{
    public class Printer
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum PrinterType
        {
            iPrint,
            Network,
            Local,
            CUPS
        }

        //Basic variables for printers
        public string Port;
        public string File ;
        public string ConfigFile;
        public string Model;
        public string Name;
        public string IP;
        public static string LogName = "Printer";

        [JsonConverter(typeof (StringEnumConverter))]
        public PrinterType Type;

        public void Remove(PrintManagerBridge instance)
        {
            try
            {
                instance.Remove(Name);
            }
            catch (Exception ex)
            {
                Log.Error(LogName, "Could not remove");
                Log.Error(LogName, ex);
            }
        }

        public void SetDefault(PrintManagerBridge instance)
        {
            Log.Entry("Printer", "Setting default: " + Name);
            try
            {
                instance.Default(Name);
            }
            catch (Exception ex)
            {
                Log.Error("Printer", ex);
            }
        }

        public void Add(PrintManagerBridge instance)
        {
            try
            {
                instance.Add(this);
            }
            catch (Exception ex)
            {
                Log.Error(LogName, "Could not add");
                Log.Error(LogName, ex);
            }
        }
    }
}