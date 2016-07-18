using System;
using Love.Net.Services;

namespace Microsoft.Extensions.DependencyInjection {
    /// <summary>
    /// Contains extension methods to <see cref="IServiceCollection"/> for configuring Sms and email services.
    /// </summary>
    public static class ApiInvokerServiceCollectionExtensions {
        /// <summary>
        /// Adds the Api invoking services to application service.
        /// </summary>
        /// <param name="services">The application services.</param>
        /// <param name="setupAction">The setup action.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddApiInvoker(this IServiceCollection services, Action<ApiInvokerOptions> setupAction) {
            if (services == null) {
                throw new ArgumentNullException(nameof(services));
            }
            if (setupAction == null) {
                throw new ArgumentNullException(nameof(setupAction));
            }

            services.Configure(setupAction);

            services.AddTransient<IEmailSender, ApiInvoker>();
            services.AddTransient<IAppPush, ApiInvoker>();
            services.AddTransient<ISmsSender, ApiInvoker>();

            return services;
        }
    }
}
