/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using Dolittle.Booting;
using Dolittle.Edge.Modules;
using Newtonsoft.Json;

namespace Dolittle.Edge.KChief
{
    /// <summary>
    /// Represents the <see cref="ICanPerformBootProcedure">boot procedure</see> that initializes the module
    /// </summary>
    public class BootProcedure : ICanPerformBootProcedure
    {
        readonly ICoordinator _coordinator;
        readonly IParser _parser; // TODO: REMOVE THIS WHEN DONE TESTING

        /// <summary>
        /// Initializes a new instance of <see cref="BootProcedure"/>
        /// </summary>
        /// <param name="coordinator"><see cref="ICoordinator"/> to initialize</param>
        /// <param name="parser">REMOVE THIS WHEN DONE TESTING</param>
        public BootProcedure(ICoordinator coordinator, IParser parser)
        {
            _coordinator = coordinator;
            _parser = parser;
        }

        /// <inheritdoc/>
        public bool CanPerform() => true;

        /// <inheritdoc/>
        public void Perform()
        {
            _coordinator.Initialize();
            
            // NOTE: This is test code that **MUST** be removed when we've verified it works (PS: clean up using statements :))
            /*
            foreach (var path in Directory.EnumerateFiles("../../sample/"))
            {
                var message = File.ReadAllBytes(path);
                _parser.Parse(message, dataPoint => {
                    var json = JsonConvert.SerializeObject(dataPoint, Formatting.None);
                    Console.Error.WriteLine(json);
                });
            }
            */
        }
    }
}