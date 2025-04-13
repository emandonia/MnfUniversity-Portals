namespace Common
{
    public enum SiteFolders
    {
        Owners_Banners,
        Owners_Icons,
        Owners_Intros,
        Owners_Logos,
        Events,
        News,
        Articles,
        Thesis,
        None,
        Events_Thumb,
        News_Thumb,
        Articles_Thumb,
        Menu,
        Staff,
        Abstracts,
        StaffBanners,
        Subjects,
        Course_Specs,
        Course_Report,
        StaffImage,
        RightLeftLinks,
        Strategy,
        Sectors,
        ItUnits,
        SMagazines,
        Library, CV, SPecial_Unit, info,Fourm,SentficResearches,
        PostDep, PostSubjects, PostPrograms, css, cammu, cedo,
        Advertisement
    }

    public enum MenuMode
    {
        Edit, Delete, Normal
    }

    public enum OwnerTypes
    {
        University = 0,
        Faculty = 1,
        Department = 2,
        Staff = 3,
        Sectors = 4,
        Subjects = 5,
        Council = 6,
        QualityUnits = 7,
        Stratigies = 8,
        ItUnits = 9,
        SMagazines = 10,
        Library = 11,
        SPecial_Unit = 12,
        infor = 13,
        PostDep = 14,
        PostSubjects = 15,
        PostPrograms = 16,
        Css = 17,
        caamu = 18,
        cedo = 19,
        ResProg=20,
        Fourm=21,
        Festival=22


    }

    public enum PageRoles
    {
        UniAdmin,
        FacAdmin,
        DepAdmin,
        FacCoAdmin,
        DepCoAdmin,
        HighlightsEditor,
        MenuEditor,
        UniCoAdmin,
        NewsEditor,
        PageEditor,
        VotingEditor,
        StaffRole, ThesisEditor, CompRole, AdminAdv
    }

    public enum PathType
    {
        Local,
        WebServer
    }
}