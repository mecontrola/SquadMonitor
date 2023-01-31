﻿using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira;
using MeControla.AgileManager.Integrations.Jira.Exceptions;
using MeControla.AgileManager.Integrations.Jira.Rest.V1.Auth;
using MeControla.AgileManager.TestingTools.NSubstitute;
using NSubstitute;
using System;
using System.Threading;

namespace MeControla.AgileManager.Core.Tests.Mocks.Services
{
    public class SessionGetMock
    {
        public static ISessionGet Create()
        {
            var mock = Substitute.For<ISessionGet>();
            mock.Execute(Arg.Any<CancellationToken>())
                .Returns(SessionDtoMock.CreateByJson());

            return mock;
        }

        public static ISessionGet CreateWithJiraAuthenticationException()
            => CreateServiceExceptionBase<AuthenticationException>();

        public static ISessionGet CreateWithJiraForbiddenException()
            => CreateServiceExceptionBase<ForbiddenException>();

        private static ISessionGet CreateServiceExceptionBase<T>()
            where T : Exception, new()
        {
            var mock = Substitute.For<ISessionGet>();
            mock.Execute(Arg.Any<CancellationToken>())
                .TaskThrows(new T());

            return mock;
        }
    }
}