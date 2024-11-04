using BeautyLand.Application.Services.Databases.MongoDatabase;
using BeautyLand.Domain.GuestUsers;
using MongoDB.Driver;
using System;
using System.Linq;

namespace BeautyLand.Application.Services.Administrator.GuestUsers.GuestUserReport
{
    public class GuestUserReportService : IGuestUserReportService
    {
        private readonly IMongoDatabaseService<GuestUser> _context;
        private readonly IMongoCollection<GuestUser> _collection;


        public GuestUserReportService(IMongoDatabaseService<GuestUser> context)
        {
            _context = context;
            _collection = _context.GetCollection();
        }

        public GuestUserReportDto Execute()
        
        {
            DateTime start = DateTime.Now.Date;
            DateTime end = DateTime.Now.AddDays(1);

            var totalViewes = _collection
              .AsQueryable()
              .LongCount();

            var totalGuestUsers = _collection
                .AsQueryable()
                .GroupBy(p => p.GuestUserId)
                .LongCount();

            var singleViewes = _collection
                .AsQueryable()
                .Where(p => p.CreateDate >= start && p.CreateDate <= end)
                .LongCount();

            var singleGuestUsers = _collection
                .AsQueryable()
                .Where(p => p.CreateDate >= start && p.CreateDate <= end)
                .GroupBy(p => p.GuestUserId)
                .LongCount();

            var recentGuestUser = _collection
                .AsQueryable()
                .OrderByDescending(p => p.CreateDate)
                .Take(10)
                .Select(p => new GuestUserGetRecentReportDto
                {
                    Id = p.Id,
                    Ip = p.Ip,
                    GuestUserId = p.GuestUserId,
                    ActiveUrl = p.ActiveUrl,
                    SourceUrl = p.SourceUrl,
                    System = p.System.Family,
                    Browser = p.Browser.Family,
                    OperatingSytem = p.OperatingSystem.Family,
                    IsSpider = p.System.IsSpider,
                    CreateDate = p.CreateDate
                }).ToList();

                GuestUserGetChartReportDto singleIllusteration = SingleViewsIllusteration(start, end);

                GuestUserGetChartReportDto totalIllusteration = TotalViewsIllusteration();

            return new GuestUserReportDto
            {
                TotalReport = new GuestUserGetCatalogReportDto
                {
                    Views = totalViewes,
                    GuestUsers = totalGuestUsers,
                    ViewsPerGuestUser = Average(totalGuestUsers, totalViewes),
                    IllusterationViews = totalIllusteration

                },
                SingleReport = new GuestUserGetCurrentReportDto
                {
                    Views = singleViewes,
                    GuestUsers = singleGuestUsers,
                    ViewsPerGuestUser = Average(singleGuestUsers, singleViewes),
                    IllusterationViews = singleIllusteration
                },
                  RecentReport = recentGuestUser,
            };
        }
        private GuestUserGetChartReportDto SingleViewsIllusteration(DateTime start, DateTime end)
        {
            var singleViewIllusteration = _collection
                .AsQueryable()
                .Where(p => p.CreateDate >= start && p.CreateDate <= end)
                .Select(p => new { p.CreateDate })
                .ToList();


            GuestUserGetChartReportDto singleIllusteration = new GuestUserGetChartReportDto
            {
                Key = new string[24],
                Value = new int[24]
            };


            for (int i = 0; i <= 23; i++)
            {
                var currentHour = DateTime.Now.AddHours(i).Hour;
                singleIllusteration.Key[i] = i.ToString();
                singleIllusteration.Value[i] = singleViewIllusteration.Where(p => p.CreateDate.Hour == currentHour).Count();

            }

            return singleIllusteration;
        }


        private GuestUserGetChartReportDto TotalViewsIllusteration()
        {
            DateTime monthStart = DateTime.Now.Date.AddDays(-30);
            DateTime monthEnd = DateTime.Now.AddDays(1);

            var totalViewsIllusteration = _collection
                .AsQueryable()
                .Where(p => p.CreateDate >= monthStart && p.CreateDate <= monthEnd)
                .Select(p => new { p.CreateDate })
                .ToList();

            GuestUserGetChartReportDto totalIllusteration = new GuestUserGetChartReportDto
            {
                Key = new string[31],
                Value = new int[31]
            };

            for (int i = 0; i <= 30; i++)
            {
                var lastMonth = DateTime.Now.AddDays(i * -1).Date;
                totalIllusteration.Key[i] = i.ToString();
                totalIllusteration.Value[i] = totalViewsIllusteration.Where(p => p.CreateDate.Date == lastMonth).Count();
            }

            return totalIllusteration;
        }
        private float Average(long guestUsers, long views)
        {
            if (views == 0)
            {
                return 0;
            }
            else
                return guestUsers / views;
        }
    }
}

