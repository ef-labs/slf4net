//The MIT License (MIT)
//Copyright © 2012 Englishtown <opensource@englishtown.com>

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the “Software”), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in
//all copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//THE SOFTWARE.


using Moq;

namespace slf4net.Moqs
{
    public static class MoqFactory
    {

        public static Mock<ILogger> Logger(string name = "")
        {
            var mock = new Mock<ILogger>();
            mock.SetupGet(m => m.Name).Returns(name);

            return mock;
        }

        public static Mock<ILoggerFactory> LoggerFactory()
        {
            var mock = new Mock<ILoggerFactory>();
            mock.Setup(m => m.GetLogger(It.IsAny<string>())).Returns((string name) => Logger(name).Object);

            return mock;
        }

        public static Mock<IFactoryResolver> FactoryResolver()
        {
            var mock = new Mock<IFactoryResolver>();
            mock.Setup(m => m.GetFactory()).Returns(MoqFactory.LoggerFactory().Object);

            return mock;
        }

    }
}
