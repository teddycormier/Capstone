using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace MyMvcApp.Controllers;

public class ArticleController : Controller
{
    [HttpGet]
    public ActionResult<IEnumerable<Article>> GetArticles()
    {
        try
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--log-level=3");

            using (IWebDriver driver = new ChromeDriver(options))
            {
                driver.Navigate().GoToUrl("https://www.everydayhealth.com/fitness/all-articles/");

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => driver.FindElements(By.CssSelector(".category-index-article")).Count > 0);
                var articles = driver.FindElements(By.CssSelector(".category-index-article")).Take(8).Select(article =>
                {
                    string title = article.FindElement(By.CssSelector(".category-index-article__title a")).Text;
                    string url = article.FindElement(By.CssSelector(".category-index-article__title a")).GetAttribute("href");
                    string imageUrl = article.FindElement(By.CssSelector(".category-index-article__image img")).GetAttribute("data-src");
                    return new Article { Title = title, Url = url, ImageUrl = imageUrl };
                }).ToList();

                return Ok(articles);
            }
        }
        catch (Exception ex)
        {
            // Log the exception message
            Console.WriteLine($"An error occurred: {ex.Message}");

            // Return a 500 status code with a generic error message
            return StatusCode(500, "An error occurred while fetching articles.");
        }
    }
}

public class Article
{
    public string Title { get; set; }
    public string Url { get; set; }
    public string ImageUrl { get; set; }
}
