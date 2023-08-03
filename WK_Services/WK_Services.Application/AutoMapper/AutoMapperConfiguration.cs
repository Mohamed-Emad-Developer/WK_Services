using AutoMapper;


namespace WK_Services.Application.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMapping()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                cfg.AddProfile(new AutoMapperProfile());
            });
        }
    }
}
