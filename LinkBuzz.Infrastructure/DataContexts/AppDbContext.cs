using LinkBuzz.Domain.Entities.ChatEntities;
using LinkBuzz.Domain.Entities.GroupEntities;
using LinkBuzz.Domain.Entities.NotificationEntities;
using LinkBuzz.Domain.Entities.PageEntities;
using LinkBuzz.Domain.Entities.PostEntities;
using LinkBuzz.Domain.Entities.StoryEntities;
using LinkBuzz.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Group = LinkBuzz.Domain.Entities.GroupEntities.Group;

namespace LinkBuzz.Infrastructure.DataContexts
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public AppDbContext() { }
        public virtual DbSet<ChatMessage> ChatMessage { get; set; }
        public virtual DbSet<ChatMessageParticipantState> ChatMessageParticipantState { get; set; }
        public virtual DbSet<Conversation> Conversation { get; set; }
        public virtual DbSet<MessageGroup> MessageGroup { get; set; }
        public virtual DbSet<MessageGroupMember> MessageGroupMember { get; set; }
        public virtual DbSet<MessageGroupReaction> MessageGroupReaction { get; set; }
        public virtual DbSet<MessageReaction> MessageReaction { get; set; }
        public virtual DbSet<MessagesInGroupMessage> MessagesInGroupMessage { get; set; }
        public virtual DbSet<Participant> Participant { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<AdminGroup> AdminGroup { get; set; }
        public virtual DbSet<GroupPost> GroupPost { get; set; }
        public virtual DbSet<JoinGroup> JoinGroup { get; set; }
        public virtual DbSet<MemberGroup> MemberGroup { get; set; }
        public virtual DbSet<ModGroup> ModGroup { get; set; }
        public virtual DbSet<MuteMember> MuteMember { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Page> Page { get; set; }
        public virtual DbSet<PageAdmin> PageAdmin { get; set; }
        public virtual DbSet<PageComment> PageComment { get; set; }
        public virtual DbSet<PageLikeComment> PageLikeComment { get; set; }
        public virtual DbSet<PageLikePost> PageLikePost { get; set; }
        public virtual DbSet<PageMod> PageMod { get; set; }
        public virtual DbSet<PagePost> PagePost { get; set; }
        public virtual DbSet<Albumn> Albumn { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<PostAlbumn> PostAlbumn { get; set; }
        public virtual DbSet<PostShare> PostShare { get; set; }
        public virtual DbSet<TagUsersInPost> TagUsersInPost { get; set; }
        public virtual DbSet<UserCommentPost> UserCommentPost { get; set; }
        public virtual DbSet<UserReactComment> UserReactComment { get; set; }
        public virtual DbSet<UserReactPost> UserReactPost { get; set; }
        public virtual DbSet<ReactStory> ReactStory { get; set; }
        public virtual DbSet<Story> Story { get; set; }
        public virtual DbSet<ConfirmEmail> ConfirmEmail { get; set; }
        public virtual DbSet<FriendShip> FriendShip { get; set; }
        public virtual DbSet<FriendShipStatus> FriendShipStatus { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<RefreshToken> RefreshToken { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserActivity> UserActivity { get; set; }
        public virtual DbSet<UserBlocked> UserBlocked { get; set; }
        public virtual DbSet<UserDevice> UserDevice { get; set; }
        public virtual DbSet<UserFollower> UserFollower { get; set; }
        public virtual DbSet<UserRelationship> UserRelationship { get; set; }
        public virtual DbSet<UserSession> UserSession  { get; set; }
        public virtual DbSet<UserStatus> UserStatus { get; set; }
        public virtual DbSet<UserViolate> UserViolate { get; set; }

        public async Task<int> CommitChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public DbSet<TEntity> SetEntity<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
