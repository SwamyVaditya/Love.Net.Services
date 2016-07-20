using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Love.Net.Services {
    /// <summary>
    /// Represents an abstraction about App push message.
    /// </summary>
    public class AppMessage {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppMessage{TContent}"/> class.
        /// </summary>
        public AppMessage() {
            Id = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the flag.
        /// </summary>
        /// <value>The flag.</value>
        /// <remarks>
        /// Application can use this value to indicate message had been read or not.
        /// </remarks>
        public int Flag { get; set; }
        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        /// <value>The kind.</value>
        /// <remarks>
        /// Application can use this value to specified the message type.
        /// </remarks>
        public string Kind { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        /// 
        public object Content { get; set; }
        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        /// <value>The link.</value>
        /// <remarks>
        /// App can use this value to indicate which page/view to render this <see cref="AppMessage{TContent}"/>.
        /// </remarks>
        public string Link { get; set; }
        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>The time.</value>
        /// <remarks>
        /// The created time of <see cref="AppMessage{TContent}"/> at server.
        /// </remarks>
        public DateTime Time { get; set; }
    }

    /// <summary>
    /// Represents an abstraction about App push message.
    /// </summary>
    public class AppMessage<TContent> : AppMessage {
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        /// 
        public new TContent Content { get; set; }
    }

    /// <summary>
    /// Some extension methods for <see cref="IAppPush"/> interface.
    /// </summary>
    public static class IAppPushExtensions {
        /// <summary>
        /// Pushes the message to list clients asynchronous.
        /// </summary>
        /// <typeparam name="TContent">The type of the content of <see cref="AppMessage{TContent}"/>.</typeparam>
        /// <param name="appPush">The instance of <see cref="IAppPush"/>.</param>
        /// <param name="appId">The app identifier.</param>
        /// <param name="message">The message.</param>
        /// <param name="targets">The target clients that message will be push to.</param>
        /// <returns>A <see cref="Task"/> represents the push operation.</returns>
        public static async Task PushMessageToListAsync<TContent>(this IAppPush appPush, string appId, AppMessage<TContent> message, params Target[] targets) {
            await appPush.PushMessageToListAsync(appId, message, targets);
        }

        /// <summary>
        /// Pushes the message to App asynchronous.
        /// </summary>
        /// <typeparam name="TContent">The type of the content of <see cref="AppMessage{TContent}"/>.</typeparam>
        /// <param name="appPush">The instance of <see cref="IAppPush"/>.</param>
        /// <param name="appId">The app identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns>A <see cref="Task"/> represents the push operation.</returns>
        public static async Task PushMessageToAppAsync<TContent>(this IAppPush appPush, string appId, AppMessage<TContent> message) {
            await appPush.PushMessageToAppAsync(appId, message);
        }
    }
}
