using LinkBuzz.Domain.Entities.ChatEntities;
using LinkBuzz.Domain.Entities.GroupEntities;
using LinkBuzz.Domain.Entities.NotificationEntities;
using LinkBuzz.Domain.Entities.PostEntities;
using LinkBuzz.Domain.Entities.StoryEntities;
using LinkBuzz.Domain.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.UserEntities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? CurrentResident { get; set; }
        public string? Story { get; set; }
        public int NumberOfFollowers { get; set; } = 0;
        public int NumberOfFriends { get; set; } = 0;
        public DateTime RegistrationDate {  get; set; }
        public ConstantEnumerates.Gender Gender { get; set; }
        public string? CurrentLocation { get; set; }
        public string? WebsiteName { get; set; }
        public ConstantEnumerates.AccountType? AccountType { get; set; } = ConstantEnumerates.AccountType.Personal;
        public DateTime? UpdateTime { get; set; }
        public ConstantEnumerates.PrivacySettings? PrivacySettings { get; set; } = ConstantEnumerates.PrivacySettings.Public;
        public string? ThumbNail { get; set; }
        public int NumberOfPagesLiked { get; set; } = 0;
        public ConstantEnumerates.RelationshipStatus RelationshipStatus { get; set; } = ConstantEnumerates.RelationshipStatus.DocThan;
        public string Avatar { get; set; }
        public bool IsLocked { get; set; } = false;
        public long UserStatusId { get; set; }
        public virtual UserStatus? UserStatus { get; set; }
        public int NumberOfViolates { get; set; } = 0;
        public DateTime? LockTime { get; set; }
        public DateTime? UnLockTime { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public virtual ICollection<UserViolate>? UserViolates { get; set; }
        public virtual ICollection<Permission>? Permissions { get; set; }
        public virtual ICollection<ConfirmEmail>? ConfirmEmails { get; set; }
        public virtual ICollection<RefreshToken>? RefreshTokens { get; set; }
        public virtual ICollection<UserFollower>? UserFollowers { get; set; }
        public virtual ICollection<UserBlocked>? UserBlocked { get; set; }
        public virtual ICollection<UserRelationship>? UserRelationships { get; set; }
        public virtual ICollection<UserDevice>? UserDevices { get; set; }
        public virtual ICollection<UserSession>? UserSessions { get; set; }
        public virtual ICollection<UserActivity>? UserActivities { get; set; }
        public virtual ICollection<UserReactPost>? UserReactPosts { get; set; }
        public virtual ICollection<UserCommentPost>? UserCommentPosts { get; set; }
        public virtual ICollection<UserReactComment>? UserReactComments { get; set; }
        public virtual ICollection<TagUsersInPost>? TagUsersInPost { get; set; }
        public virtual ICollection<PostShare>? PostShares { get; set; }
        public virtual ICollection<ChatMessage>? ChatMessages { get; set; } 
        public virtual ICollection<Conversation>? Conversations { get; set; }
        public virtual ICollection<Participant>? Participants { get; set; }
        public virtual ICollection<MessageReaction>? MessageReactions { get; set; }
        public virtual ICollection<MessageGroupMember>? MessageGroupMembers { get; set; }
        public virtual ICollection<MessagesInGroupMessage>? MessagesInGroupMessages { get; set; }
        public virtual ICollection<MessageGroupReaction>? MessageGroupReactions { get; set; }
        public virtual ICollection<Notification>? Notifications { get; set; }
        public virtual ICollection<Story>? Stories { get; set; }
        public virtual ICollection<ReactStory>? ReactStory { get; set; }
        public virtual ICollection<AdminGroup>? AdminGroups { get; set; }
        public virtual ICollection<JoinGroup>? JoinGroups { get; set; }
        public virtual ICollection<MemberGroup>? MemberGroups { get; set; }
        public virtual ICollection<GroupPost>? GroupPosts { get; set; }
        public virtual ICollection<MuteMember>? MuteMembers { get; set; }
    }
}
