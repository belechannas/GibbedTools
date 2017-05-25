﻿/* Copyright (c) 2012 Rick (rick 'at' gibbed 'dot' us)
 * 
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 * 
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 * 
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

using System;
using ParserSchema = Gibbed.Cryptic.FileFormats.ParserSchema;

namespace Gibbed.Cryptic.GenerateSerializer
{
    internal class QueuedType
    {
        public string Name;
        public ParserSchema.Table Table;
        public QueuedType Parent;

        public QueuedType()
            : this(null, null, null)
        {
        }

        public QueuedType(string name, ParserSchema.Table table)
            : this(name, table, null)
        {
        }

        public QueuedType(string name, ParserSchema.Table table, QueuedType parent)
        {
            if (name != null && string.IsNullOrEmpty(name) == true)
            {
                //Console.WriteLine("Invalid name: ({0}), parent name: ({1}), parent key: ({2})", name, parent.Name, parent.Key );
                //foreach (var c in table.Columns)
                //{
                //    Console.WriteLine("Invalid QueuedType table column: {0}", c.Name);
                //}
                throw new ArgumentException();
            }

            this.Name = name;
            this.Table = table;
            this.Parent = parent;
        }

        public string Key
        {
            get
            {
                if (this.Parent == null)
                {
                    return this.Name;
                }

                return this.Parent.Key + "." + this.Name;
            }
        }
    }
}
