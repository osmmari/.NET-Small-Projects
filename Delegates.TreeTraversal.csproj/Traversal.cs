using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.TreeTraversal
{
    public static class Traversal
    {
        private static IEnumerable<T> Traverse<T, Data>(Data data, Func<Data, IEnumerable<T>> function)
        {
            var result = function(data);
            return result;
        }

        private static IEnumerable<int> TraverseBinaryTree(BinaryTree<int> data)
        {
            if (data != null)
            {
                yield return data.Value;
                if (data.Left != null)
                {
                    foreach (var item in TraverseBinaryTree(data.Left))
                    yield return item;
                }
                if (data.Right != null)
                {
                    foreach (var item in TraverseBinaryTree(data.Right))
                        yield return item;
                }
            }
        }

        private static IEnumerable<Job> TraverseJobs(Job data)
        {
            if (data != null)
            {
                if (data.Subjobs != null && data.Subjobs.Count > 0)
                {
                    foreach (var job in data.Subjobs)
                        foreach (var item in TraverseJobs(job))
                            yield return item;
                }
                else
                    yield return data;
            }
        }

        private static IEnumerable<Product> TraverseProducts(ProductCategory data)
        {
			foreach (var category in data.Categories)
			{
				foreach (var item in TraverseProducts (category))
					yield return item;
			}
			foreach (var product in data.Products)
			{
				yield return product;
			}
        }
        //---------------------------------------------------------------//

        public static IEnumerable<int> GetBinaryTreeValues(BinaryTree<int> data)
        {
            return Traverse(data, TraverseBinaryTree);
        }

        public static IEnumerable<Job> GetEndJobs(Job data)
        {
            return Traverse(data, TraverseJobs);
        }

        public static IEnumerable<Product> GetProducts(ProductCategory data)
        {
            return Traverse(data, TraverseProducts);
        }
    }
}
