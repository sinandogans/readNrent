package com.sinandogans.readnrent.domain.user;

import com.sinandogans.readnrent.domain.book.Comment;
import com.sinandogans.readnrent.domain.book.Review;
import com.sinandogans.readnrent.domain.library.ReadingGoal;
import com.sinandogans.readnrent.domain.library.UserBook;
import com.sinandogans.readnrent.domain.rentandsale.rent.Rent;
import com.sinandogans.readnrent.domain.rentandsale.rent.RentBook;
import com.sinandogans.readnrent.domain.rentandsale.sale.Sale;
import com.sinandogans.readnrent.domain.rentandsale.sale.SaleBook;
import jakarta.persistence.*;
import jakarta.validation.constraints.Email;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;
import java.util.Objects;

@Entity
@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
@Table(name = "users")
public class User {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    @Email(message = "email formati yanlis bro")
    private String email;
    private String username;
    private String firstName;
    private String lastName;
    private String profilePhotoPath;
    private String coverPhotoPath;
    private byte[] passwordSalt;
    private byte[] passwordHash;
    private boolean verified;
    @ManyToMany
    private List<UserRole> roles = new ArrayList<>();
    @OneToMany(mappedBy = "user")
    private List<UserBook> userBooks = new ArrayList<>();
    @OneToMany(mappedBy = "user")
    private List<ReadingGoal> readingGoals = new ArrayList<>();
    @OneToMany(mappedBy = "follower")
    private List<Follow> following = new ArrayList<>();
    @OneToMany(mappedBy = "followed")
    private List<Follow> follower = new ArrayList<>();
    @OneToMany(mappedBy = "user")
    private List<BlockedUser> blockedUsers = new ArrayList<>();
    @ManyToMany(mappedBy = "usersLiked")
    private List<Review> reviewsLiked = new ArrayList<>();
    @ManyToMany(mappedBy = "usersLiked")
    private List<Comment> commentsLiked = new ArrayList<>();
    @ManyToMany
    private List<Comment> comments = new ArrayList<>();
    @OneToMany(mappedBy = "user")
    private List<Review> reviews = new ArrayList<>();
    @OneToMany(mappedBy = "user")
    private List<RentBook> rentBooks = new ArrayList<>();
    @OneToMany(mappedBy = "user")
    private List<SaleBook> saleBooks = new ArrayList<>();
    @OneToMany(mappedBy = "user")
    private List<Rent> rents = new ArrayList<>();
    @OneToMany(mappedBy = "user")
    private List<Sale> sales = new ArrayList<>();
    @OneToMany(mappedBy = "user")
    private List<Address> addresses = new ArrayList<>();

    public void addRole(UserRole roleToAdd) {
        var index = roles.indexOf(roleToAdd);
        if (index != -1)
            throw new RuntimeException("bu rol kullanicida zaten var");
        roles.add(roleToAdd);
    }

    public void deleteRole(UserRole roleToDelete) {
        var isDeleted = roles.remove(roleToDelete);
        if (!isDeleted)
            throw new RuntimeException("bu rol kullanicida yok");
    }

    public void addFollowing(Follow userToFollow) {
        var filteredUsers = following.stream().filter(follow -> follow.getFollowed() == userToFollow.getFollowed()).toList();
        if (!filteredUsers.isEmpty())
            throw new RuntimeException("bu kullanıcı zaten takip ediliyor");
        following.add(userToFollow);
    }

    public void likeReview(Review reviewToLike) {
        var index = reviewsLiked.indexOf(reviewToLike);
        if (index == -1)
            reviewsLiked.add(reviewToLike);
        else
            reviewsLiked.remove(index);
    }

    public void likeComment(Comment commentToLike) {
        var index = commentsLiked.indexOf(commentToLike);
        if (index == -1)
            commentsLiked.add(commentToLike);
        else
            commentsLiked.remove(index);
    }

    public boolean isUserFollowing(User user) {
        var count = following.stream().filter(follow -> follow.getFollowed() == user).count();
        return count != 0;
    }

    public boolean isUserBlocked(User user) {
        var count = blockedUsers.stream().filter(blockedUser -> blockedUser.getBlockedUser() == user).count();
        return count != 0;
    }

    public Long removeFollowing(User userToUnfollow) {
        var filteredUsers = following.stream().filter(follow -> follow.getFollowed() == userToUnfollow).toList();
        if (filteredUsers.isEmpty())
            throw new RuntimeException("bu kullanıcı takip edilmiyor");
        var id = filteredUsers.get(0).getId();
        following = following.stream().filter(follow -> follow.getFollowed() != userToUnfollow).toList();
        return id;
    }

    public Follow getFollow(String username) {
        var filteredUsers = following.stream().filter(follow -> Objects.equals(follow.getFollowed().getUsername(), username)).toList();
        if (filteredUsers.isEmpty())
            throw new RuntimeException("bu kullanıcı takip edilmiyor");
        return filteredUsers.get(0);
    }

    public void addBlockedUser(BlockedUser blockedUserToAdd) {
        var filteredUsers = blockedUsers.stream().filter(blockedUser -> blockedUser.getBlockedUser() == blockedUserToAdd.getBlockedUser()).toList();
        if (!filteredUsers.isEmpty())
            throw new RuntimeException("bu kullanıcı zaten blocklu");
        blockedUsers.add(blockedUserToAdd);
    }

    public Long removeBlockedUser(User userToUnBlock) {
        var filteredUsers = blockedUsers.stream().filter(blockedUser -> blockedUser.getBlockedUser() == userToUnBlock).toList();
        if (filteredUsers.isEmpty())
            throw new RuntimeException("bu kullanıcı blocklu degil");
        var id = filteredUsers.get(0).getId();
        blockedUsers = blockedUsers.stream().filter(blockedUser -> blockedUser.getBlockedUser() != userToUnBlock).toList();
        return id;
    }

    public ReadingGoal getCurrentReadingGoal() {
        var readingGoalsList = readingGoals.stream().filter(readingGoal -> readingGoal.getYear() == LocalDate.now().getYear()).toList();
        if (readingGoalsList.isEmpty())
            throw new RuntimeException("bu yil reading goal yok");
        return readingGoalsList.get(0);
    }

    public String getFullName() {
        return firstName + " " + lastName;
    }

    public List<String> getRoles() {
        return roles.stream().map(roles -> roles.getRole()).toList();
    }
}
