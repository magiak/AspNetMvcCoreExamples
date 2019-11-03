using System;
using Xunit;

namespace AspNetMvcCoreExamples.XUnitTests
{
    public class GenericTests
    {
        // Contravariance (IN) VS Covariance (OUT)
        // Contravariance enables you to use a less derived type than that specified by the generic parameter
        // Covariance enables you to use a more derived type than that specified by the generic parameter. 
        // Covariance and contravariance in generic type parameters are supported for reference types, but they are not supported for value types.

        // Contravariant interface.
        interface IContravariant<in A> { }

        // Extending contravariant interface.
        //interface IExtContravariant<in A> : IContravariant<A> { }

        // Implementing contravariant interface.
        class ContravariantSample<A> : IContravariant<A> { }

        [Fact]
        public void Contravariant()
        {
            IContravariant<Object> iobj = new ContravariantSample<Object>();
            IContravariant<String> istr = new ContravariantSample<String>();

            // You can assign iobj to istr because
            // the IContravariant interface is contravariant.
            istr = iobj;

            // iobj = istr; // Can not
        }


        // Covariant interface.
        interface ICovariant<out R> { }

        // Extending covariant interface.
        //interface IExtCovariant<out R> : ICovariant<R> { }

        // Implementing covariant interface.
        class CovariantSample<R> : ICovariant<R> { }

        [Fact]
        public void Covariant()
        {
            ICovariant<Object> iobj = new CovariantSample<Object>();
            ICovariant<String> istr = new CovariantSample<String>();

            // You can assign istr to iobj because
            // the ICovariant interface is covariant.
            iobj = istr;

            // istr = iobj; // Can not
        }
    }
}
