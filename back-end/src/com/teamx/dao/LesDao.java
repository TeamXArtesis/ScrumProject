package com.teamx.dao;

import java.util.List;

import com.teamx.domain.Les;

public interface LesDao {

	public List<Les> findAll();
	public Les findLesById(int id);
	public void create(Les les);
	public void delete(int id);
	public void delete(Les les);
}
