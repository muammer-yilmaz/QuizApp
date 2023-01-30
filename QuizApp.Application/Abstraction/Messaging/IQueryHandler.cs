using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Application.Abstraction.Messaging
{
    public interface IQueryHander<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
            where TQuery : IQuery<TResponse>
    {
    }
}
