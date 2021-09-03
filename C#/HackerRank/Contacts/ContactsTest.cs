using Xunit;

namespace HackerRank;
public class ContactsTest
{
    [Fact]
    public void TestContacts()
    {
        var contacts = new Contacts.Solution();
        contacts.Add("ed");
        contacts.Add("eddie");
        contacts.Add("edward");
        var result = contacts.Find("ed");
        Assert.Equal(3, result);
        contacts.Add("edwina");
        result = contacts.Find("edw");
        Assert.Equal(2, result);
        result = contacts.Find("a");
        Assert.Equal(0, result);
    }
    [Fact]
    public void TestContacts1()
    {
        var contacts = new Contacts.Solution();
        contacts.Add("hack");
        contacts.Add("hackerrank");
        var result = contacts.Find("hac");
        Assert.Equal(2, result);
        result = contacts.Find("hak");
        Assert.Equal(0, result);
    }

}