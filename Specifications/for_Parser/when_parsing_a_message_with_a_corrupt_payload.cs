/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Machine.Specifications;

namespace Dolittle.TimeSeries.KChief.for_Parser
{
    [Subject(typeof(Parser))]
    public class when_parsing_a_message_with_a_corrupt_payload : given.a_parser
    {
        Because of = () =>
        {
            var data = new byte[]
            {
                0x08, 0x01, // Library version
                0x18, 0x00, // Not compressed
                0x22, 0x34, // Message is 52 big

                0x0a, 0x32, // Payload of size 50
                0x1f, 0x30, 0x0a, 0x14, 0x43, 0x36, 0x30, 0x30, 0x2e, 0x54,
                0x61, 0x67, 0x2e, 0x43, 0x59, 0x4c, 0x30, 0x32, 0x5f, 0x42,
                0x57, 0x43, 0x2d, 0x32, 0x12, 0x18, 0x0a, 0x0c, 0x08, 0xf3,
                0xd3, 0x9b, 0xe5, 0x05, 0x10, 0xec, 0x86, 0xfa, 0xbc, 0x01,
                0x12, 0x08, 0xd9, 0xce, 0xf7, 0x53, 0xe3, 0xa5, 0xab, 0xbf,
            };

            parser.Parse(data, datapoints.Add);
        };

        It should_add_no_datapoints = () => datapoints.Count.ShouldEqual(0);
        It should_have_logged_errors = () => errors.Count.ShouldBeGreaterThanOrEqualTo(1);
    }
}