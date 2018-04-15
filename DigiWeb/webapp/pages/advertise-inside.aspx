<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/pages/HomeMasterPage.master" CodeFile="advertise-inside.aspx.cs" Inherits="pages_advertise_inside" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>招聘内页</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
        <!-- answer-main -->
    <div class="advertise-main clearfix">
    	<div class="wrap advertise-main-container clearfix">
    		<div class="advertise-title">
    			<img src="../images/advertise_search.jpg" alt="">
    		</div>
    		<!-- advertise-cont -->
    		<div class="advertise-inside-cont clearfix">
    			<!-- advertise-from -->
    			<div class="advertise-from">
    				<div class="row" style="padding-bottom: 20px;">
    					<div class="col-md-3 form-inline">
    						  <div class="form-group">
							   	 <label for="exampleInputName1">面试地点:</label>
								   <select class="form-control job-area">
									  <option>请选择</option>
									  <option>2</option>
									  <option>3</option>
									  <option>4</option>
									  <option>5</option>
									</select>
							  </div>
    					</div>
    					<div class="col-md-5 form-inline">
    						 <div class="form-group">
							    <label for="exampleInputName2">职位名称：</label>
							    <input type="text" class="form-control job-name" id="exampleInputName2" placeholder="">
							  </div>
    					</div>
    					<div class="col-md-4 form-inline">
    						<div class="form-group">
							    <label for="exampleInputName2">职位名称：</label>
							     <select class="form-control job-country">
									  <option>中国</option>
									  <option>2</option>
									  <option>3</option>
									  <option>4</option>
									  <option>5</option>
								 </select>
								  <select class="form-control job-city">
									  <option>上海</option>
									  <option>2</option>
									  <option>3</option>
									  <option>4</option>
									  <option>5</option>
								 </select>

							 </div>
    					</div>
    				</div>
    				<div class="row">
    					<div class="col-md-3 form-inline">
    						  <div class="form-group">
							   	 <label for="exampleInputName1">职位类型:</label>
								   <select class="form-control job-area">
									  <option>请选择</option>
									  <option>2</option>
									  <option>3</option>
									  <option>4</option>
									  <option>5</option>
									</select>
							  </div>
    					</div>
    					<div class="col-md-9 form-inline form-job-radio">
    						  <div class="form-group">
	    						 <label for="exampleInputName1">工作时间:</label>
	    						<label class="radio-inline">
								  <input type="radio" name="inlineRadioOptions" id="inlineRadio1" value="option1"> 全部
								</label>
								<label class="radio-inline">
								  <input type="radio" name="inlineRadioOptions" id="inlineRadio1" value="option1"> 全职
								</label>
								<label class="radio-inline">
								  <input type="radio" name="inlineRadioOptions" id="inlineRadio1" value="option1"> 兼职
								</label>
								<a class="large button yellow">搜索职位</a>
							</div>
    					</div>
    				</div>
    			</div>
    			<!-- advertise-from -->
    			<div class="advertise-title">
    				<img src="../images/advertise_school.jpg" alt="">
    			</div>
    			<!-- advertise-table -->
    			<div class="advertise-table row">
    				<table class="table table-hover text-center">
				      <thead>
				        <tr>
				          <th style="width: 10%">

							  <label>
							    <input type="checkbox" id="blankCheckbox" value="option1" >
							  </label>
							
						   </th>
				          <th style="width: 18%">招聘职位</th>
				          <th style="width: 18%">地点</th>
				          <th style="width: 18%">招聘人数</th>
				          <th style="width: 18%">工资待遇</th>
				          <th style="width: 18%;">发布时间</th>
				        </tr>
				      </thead>
				      <tbody>
				        <tr>
					          <td>
					          	<label>
								    <input type="checkbox" id="blankCheckbox" value="option1" >
								</label>
							  </td>
					          <td><a href="#">系统流程专员</a></td>
					          <td>北京</td>
					          <td>50人</td>
					   		  <td>3000-4000元</td>
					          <td>2017-09-22</td>
				        </tr>
				         <tr>
					          <td>
					          	<label>
								    <input type="checkbox" id="blankCheckbox" value="option1" >
								</label>
							  </td>
					          <td><a href="#">系统流程专员</a></td>
					          <td>北京</td>
					          <td>50人</td>
					   		  <td>3000-4000元</td>
					          <td>2017-09-22</td>
				        </tr>
				         <tr>
					          <td>
					          	<label>
								    <input type="checkbox" id="blankCheckbox" value="option1" >
								</label>
							  </td>
					          <td><a href="#">系统流程专员</a></td>
					          <td>北京</td>
					          <td>50人</td>
					   		  <td>3000-4000元</td>
					          <td>2017-09-22</td>
				        </tr>
				         <tr>
					          <td>
					          	<label>
								    <input type="checkbox" id="blankCheckbox" value="option1" >
								</label>
							  </td>
					          <td><a href="#">系统流程专员</a></td>
					          <td>北京</td>
					          <td>50人</td>
					   		  <td>3000-4000元</td>
					          <td>2017-09-22</td>
				        </tr>
				         <tr>
					          <td>
					          	<label>
								    <input type="checkbox" id="blankCheckbox" value="option1" >
								</label>
							  </td>
					          <td><a href="#">系统流程专员</a></td>
					          <td>北京</td>
					          <td>50人</td>
					   		  <td>3000-4000元</td>
					          <td>2017-09-22</td>
				        </tr>
				         <tr>
					          <td>
					          	<label>
								    <input type="checkbox" id="blankCheckbox" value="option1" >
								</label>
							  </td>
					          <td><a href="#">系统流程专员</a></td>
					          <td>北京</td>
					          <td>50人</td>
					   		  <td>3000-4000元</td>
					          <td>2017-09-22</td>
				        </tr>
				         <tr>
					          <td>
					          	<label>
								    <input type="checkbox" id="blankCheckbox" value="option1" >
								</label>
							  </td>
					          <td><a href="#">系统流程专员</a></td>
					          <td>北京</td>
					          <td>50人</td>
					   		  <td>3000-4000元</td>
					          <td>2017-09-22</td>
				        </tr>
				         <tr>
					          <td>
					          	<label>
								    <input type="checkbox" id="blankCheckbox" value="option1" >
								</label>
							  </td>
					          <td><a href="#">系统流程专员</a></td>
					          <td>北京</td>
					          <td>50人</td>
					   		  <td>3000-4000元</td>
					          <td>2017-09-22</td>
				        </tr>
				         <tr>
					          <td>
					          	<label>
								    <input type="checkbox" id="blankCheckbox" value="option1" >
								</label>
							  </td>
					          <td><a href="#">系统流程专员</a></td>
					          <td>北京</td>
					          <td>50人</td>
					   		  <td>3000-4000元</td>
					          <td>2017-09-22</td>
				        </tr>
				         <tr>
					          <td>
					          	<label>
								    <input type="checkbox" id="blankCheckbox" value="option1" >
								</label>
							  </td>
					          <td><a href="#">系统流程专员</a></td>
					          <td>北京</td>
					          <td>50人</td>
					   		  <td>3000-4000元</td>
					          <td>2017-09-22</td>
				        </tr>
				         <tr>
					          <td>
					          	<label>
								    <input type="checkbox" id="blankCheckbox" value="option1" >
								</label>
							  </td>
					          <td><a href="#">系统流程专员</a></td>
					          <td>北京</td>
					          <td>50人</td>
					   		  <td>3000-4000元</td>
					          <td>2017-09-22</td>
				        </tr>

				      </tbody>
				    </table>

    			</div>
				<!-- advertise-table -->
				<div class="row search-btn text-center">
					<a class="large button yellow">加入我的职位</a>
					<a class="large button orange">加入我的职位</a>
					
				</div>
    		</div>
    		<!-- advertise-cont -->
    	</div>
    </div>
     <!-- answer-main -->
</asp:Content>